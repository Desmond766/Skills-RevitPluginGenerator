---
kind: method
id: M:Autodesk.Revit.DB.ElementType.GetPreviewImage(System.Drawing.Size)
source: html/e79da134-713a-2202-4898-cca930202dff.htm
---
# Autodesk.Revit.DB.ElementType.GetPreviewImage Method

Get the preview image of an element. This image is similar to what is seen in the Revit UI when selecting the type of an element.

## Syntax (C#)
```csharp
public virtual Bitmap GetPreviewImage(
	Size size
)
```

## Parameters
- **size** (`System.Drawing.Size`) - The width and height of the preview image in pixels.

## Returns
System::Drawing::Bitmap represents the preview image. Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no preview image.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The width or height of the size is equal or less than zero.

