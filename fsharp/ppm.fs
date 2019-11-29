open System

//Defined Presets
let version = "P3"  // P3 for readable text, P6 for binary
let res = "256 256" // image width and height
let maxVal = "255"  // max color value
let Color = {red: System.int; green: System.int; blue: System.int;}

//Red Green Gredient
let rec makePPM color =
	if (color.red = 255) then color
	elif (color.green = 255) then color

	printfn "%s %s %s" color.red color.green color.blue

	(makePPM color.green + 1)
	(makePPM color.red + 1)

colorBlack = {red: 0; green: 0; blue: 0;}

makePPM colorBlack
