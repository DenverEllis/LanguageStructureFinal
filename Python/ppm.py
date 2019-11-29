#PPM Header
width  = 256
height = 256
maxval = 255
header = 'P3\n' + str(width) + ' ' + str(height) + '\n' + str(maxval) + '\n'

# Data Array
img = []

#generation function for red and green:
def generatePPMRG():
    for x in range(0, height):
        for y in range(0, width):
            temp = (x, y, 0)
            img.append(temp)

#generation function for red and blue:
def generatePPMRB():
    for x in range(0, height):
        for y in range(0, width):
            temp = (x, 0, y)
            img.append(temp)

#generation function for green and blue:
def generatePPMGB():
    for x in range(0, height):
        for y in range(0, width):
            temp = (0, x, y)
            img.append(temp)

#generation function for green and red:
def generatePPMGR():
    for x in range(0, height):
        for y in range(0, width):
            temp = (y, x, 0)
            img.append(temp)

#generation function for blue and red:
def generatePPMBR():
    for x in range(0, height):
        for y in range(0, width):
            temp = (y, 0, x)
            img.append(temp)

#generation function for blue and green:
def generatePPMBG():
    for x in range(0, height):
        for y in range(0, width):
            temp = (0, x, y)
            img.append(temp)

#function call. make a switch later
generatePPMRG()

#write image to file
with open("out.ppm", 'w') as f:
    f.write(header)
    for x in range(0,len(img)):
        r,g,b = img[x]
        f.write(str(r) + ' ' + str(g) + ' ' + str(b) + '\n')
