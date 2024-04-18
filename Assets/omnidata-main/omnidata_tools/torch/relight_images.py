import torch
import torch.nn.functional as F
from torchvision import transforms

import PIL
from PIL import Image
import numpy as np
import matplotlib.pyplot as plt

import argparse
import os.path
from pathlib import Path
import glob
import sys

import pdb

from modules.unet import UNet
from modules.midas.dpt_depth import DPTDepthModel
from data.transforms import get_transform


device = torch.device('cuda:0' if torch.cuda.is_available() else 'cpu')
trans_topil = transforms.ToPILImage()
# 재조명 기능을 위한 함수
def relight_image(image_path, output_path, new_light_intensity):
    image_size = 384
    trans_totensor = transforms.Compose([
        transforms.Resize(image_size, interpolation=PIL.Image.BILINEAR),
        transforms.CenterCrop(image_size),
        transforms.ToTensor(),
        transforms.Normalize(mean=0.5, std=0.5)
    ])
    with torch.no_grad():
        # 이미지 로드
        img = Image.open(image_path)

        # 이미지를 텐서로 변환하고 디바이스로 전송
        img_tensor = trans_totensor(img)[:3].unsqueeze(0).to(device)
        model = DPTDepthModel(backbone='vitb_rn50_384', num_channels=3)

        # 모델을 사용하여 이미지에 새로운 조명 적용
        output = model(img_tensor).clamp(min=0, max=1) * new_light_intensity

        # 결과를 파일로 저장
        output_file_name = os.path.basename(image_path)
        save_path = os.path.join(output_path, output_file_name)
        trans_topil(output[0]).save(save_path)

        print(f'Writing output {save_path} ...')

# 인자 파싱
parser = argparse.ArgumentParser(description='Apply relighting to images')
parser.add_argument('--image_path', type=str, help='Path to input image or directory of images')
parser.add_argument('--output_path', type=str, help='Path to save relighted images')
parser.add_argument('--new_light_intensity', type=float, default=1.0, help='New light intensity (default: 1.0)')
args = parser.parse_args()

# 모델 초기화 및 전처리 설정 (위 코드에서 이미 초기화 및 설정되어 있음)

# 이미지 경로가 디렉토리인지 단일 파일인지 확인
if os.path.isdir(args.image_path):
    image_paths = glob.glob(os.path.join(args.image_path, '*'))
else:
    image_paths = [args.image_path]

# 모든 이미지에 재조명 기능 적용
for image_path in image_paths:
    relight_image(image_path, args.output_path, args.new_light_intensity)