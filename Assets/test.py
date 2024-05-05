import sys
import json

from PIL import Image
from imaginairy_normal_map.model import create_normal_map_pil_img
imagePath = "D:/Minecraft_Plugins/testest/Assets/Resources/Images/KakaoTalk_20240502_154951629.jpg"
#imagePath= "C:/Users/10Group/Documents/GitHub/testest/Assets/Resources/Images/KakaoTalk_20240502_154951629.jpg"
if len(sys.argv) > 1:
    received_message = sys.argv[1]
    print(json.dumps(received_message))

img = Image.open(imagePath) #원본
normal_img = create_normal_map_pil_img(img)
divide = imagePath.split('.')
normal_img.save(divide[0] + "_normal." + divide[1]) #생성본

