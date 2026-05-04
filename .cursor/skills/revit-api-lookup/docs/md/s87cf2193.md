---
kind: method
id: M:Autodesk.Revit.DB.InCanvasControlData.#ctor(System.String,Autodesk.Revit.DB.XYZ)
source: html/f16cf225-d5a1-96e8-d036-bcda9f5dd8d1.htm
---
# Autodesk.Revit.DB.InCanvasControlData.#ctor Method

Constructs an InCanvasControlData with specific values assigned.

## Syntax (C#)
```csharp
public InCanvasControlData(
	string imagePath,
	XYZ position
)
```

## Parameters
- **imagePath** (`System.String`) - File path with the image to be used.
 This must be an absolute path to a location on disk.
- **position** (`Autodesk.Revit.DB.XYZ`) - The position to be used.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The file format specified by imagePath is an unsupported format - only *.bmp files are supported.
 -or-
 The file path specified by imagePath is not absolute.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The file specified by imagePath doesn't exist.

