open System

type Color = {red: byte; green: byte; blue: byte;}
type Point = {x: uint32; y: uint32;}
type PPM = {color: Color array; maxX: uint32; maxY: uint32;}

let colorBlack = {red: (byte) 0; green: (byte) 0; blue: (byte) 0;}
let emptyPPM = {color: Array.empty; maxX: (uint32) 0; maxY: (uint32) 0;}
let ppm (width: uint32) (height: uint32) = 
	match width, height with
	| 0u, 0u | 0u,_ | _, 0u -> emptyPPM
	| _,_ -> {color = Array.create ((int) (width * height)) colorBlack;
			maxX = width;
			maxy = height;}

let getPixel point ppm = 
	match ppm.color with
	| c when c |> Array.isEmpty -> None
	| c when (uint32) c.Length <= (point.y * ppm.maxY + point.x) -> None
	| c -> Some c.[(int) (point.y * ppm.maxY + point.x)]

let setPixel point color ppm = 
	{ppm with color = ppm.color |> Array.mapi (function
				| i when i = (int) (point.y * ppm.maxY + point.x)
					(fun _ -> color)
				| _ -> id)}

let fill color ppm = {ppm with color = ppm.color |> Array.map (fun _ -> color)}