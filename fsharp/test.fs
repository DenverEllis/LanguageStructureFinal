type Color = {red: uint32; green: uint32; blue: uint32;}
type Point = {x: uint32; y: uint32;}
type PPM =  {version: string; resX: uint32; resY: uint32; maxVal: uint32; color: Color array;}

let colorBlack = {red: (uint32) 0; green: (uint32) 0; blue: (uint32) 0;}
let emptyPPM =  {version: "P3"; resX: (uint32) 0; resy: (uint32) 0; maxVal: (uint32) 0; color: Array.empty;}
let ppm (width: uint32) (height: uint32) =
	match width, height with
	| 0, 0 | 0,_ | _, 0 -> emptyPPM
	| _,_ -> {version = "P3";
			resX = width;
			resY = height;
			maxVal = 255
			color =  Array.create ((int) (width * height)) colorBlack;}

let getPixel point ppm =
	match ppm.color with
	| c when c |> Array.isEmpty -> None
	| c when (uint32) c.Length <= (point.y *ppm.resY + point.x) -> None
	| c -> Some c.[(int) ([point.y * ppm.resY + point.x)]

let setPixel point color ppm =
	{ppm with color = ppm.color |> Array.mapi (function
				| i when i = (int) (point.y * ppm.resY + point.x)
					(fun _ -> color)
				| _ -> id)}

let file color ppm = {ppm with color = ppm.color |> Array.map (fun _ -> color)}