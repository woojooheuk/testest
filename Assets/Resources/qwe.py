import os

script_dir = os.path.dirname(os.path.realpath(__file__))

Txtfile_name = "TxtPath.txt"
Txtfile_path = os.path.join(script_dir, Txtfile_name)

with open(Txtfile_path, 'r') as file:
    lines = file.readlines()

modified_lines = []
if len(lines) > 1:
    for line in lines:
        modified_line = line.replace(lines[1], lines[0] + "_normal")
        modified_lines.append(modified_line)
else:
    modified_lines = [lines[0]+"\n", lines[0] + "_normal"]
with open(Txtfile_path, 'w') as file:
    file.writelines(modified_lines)
        
