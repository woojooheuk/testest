from PIL import Image
from imaginairy_normal_map.model import create_normal_map_pil_img

img = Image.open("D:/Minecraft_Plugins/testest/Assets/plz.jpeg")
normal_img = create_normal_map_pil_img(img)
normal_img.save("D:/Minecraft_Plugins/testest/Assets/plz_normal.jpeg")
