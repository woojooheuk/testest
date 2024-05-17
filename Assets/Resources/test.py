from PIL import Image
from imaginairy_normal_map.model import create_normal_map_pil_img
import firebase_admin
from firebase_admin import credentials, storage
from flask import Flask, request, jsonify
import io
import traceback

cred = credentials.Certificate("C:/Users/dnheu/Downloads/graduation-5bbb7-firebase-adminsdk-y7md4-14930d910c.json")
firebase_admin.initialize_app(cred, {
    'storageBucket': 'graduation-5bbb7.appspot.com'
})
bucket = storage.bucket()

app = Flask(__name__)

def makeNormalMap(image_data):
    try:
        img = Image.open(io.BytesIO(image_data))
        normal_img = create_normal_map_pil_img(img)

        output_buffer = io.BytesIO()
        normal_img.save(output_buffer, format='jpg')
        output_buffer.seek(0)

        return output_buffer
    
    except Exception as e:
        print("Error: ", e)
        return None
        
@app.route('/process_image', methods=['POST'])
def process_image():
    if 'image' not in request.files:
        return jsonify({'error': 'No image uploaded'}), 400
    
    image_file = request.files['image']
    image_data = image_file.read()
    original_filename = image_file.filename
    
    try:
        output_buffer = makeNormalMap(image_data)
        
        if output_buffer:
            blob = bucket.blob(f"normal/{original_filename}")
            blob.upload_from_file(output_buffer, content_type = image_file.content_type)
            
            return jsonify({'processed_image_url': blob.public_url}), 200
        else:
            return jsonify({'error': 'Failed to process the image'}), 500
        
    except Exception as e:
        traceback.print_exc()
        return jsonify({'error': str(e)}), 500
    
if __name__ == '__main__':
    app.run(debug=True)
