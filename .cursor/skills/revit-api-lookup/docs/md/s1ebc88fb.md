---
kind: method
id: M:Autodesk.Revit.DB.ViewDisplayBackground.CreateImage(System.String,Autodesk.Revit.DB.ViewDisplayBackgroundImageFlags,Autodesk.Revit.DB.UV,Autodesk.Revit.DB.UV)
source: html/63388ef3-4b6c-ef0a-1a70-906dcb8d6457.htm
---
# Autodesk.Revit.DB.ViewDisplayBackground.CreateImage Method

Creates an object that can be passed to View.SetBackground method
 to set the background of the Image type.

## Syntax (C#)
```csharp
public static ViewDisplayBackground CreateImage(
	string imagePath,
	ViewDisplayBackgroundImageFlags flags,
	UV imageOffsets,
	UV imageScales
)
```

## Parameters
- **imagePath** (`System.String`) - File path with the image to be used.
- **flags** (`Autodesk.Revit.DB.ViewDisplayBackgroundImageFlags`) - Combination of flags (binary) that control how image is displayed in relation
 to the view/crop boundary.
- **imageOffsets** (`Autodesk.Revit.DB.UV`) - Horizontal (u) and vertical (v) offsets of the image.
- **imageScales** (`Autodesk.Revit.DB.UV`) - Horizontal (u) and vertical (v) scales of the image (1 == no change).

## Returns
New background object to pass to View.SetBackground .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The file specified by imagePath is not an image file.
 A valid image file should be in one of the following formats: bmp, jpg, jpeg, png, tif.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The file specified by imagePath doesn't exist.

