---
kind: type
id: T:Autodesk.Revit.DB.InCanvasControlData
source: html/5fdf010d-7dbb-332d-4704-8e067f2338dc.htm
---
# Autodesk.Revit.DB.InCanvasControlData

Represents a collection of data which is used by [!:Autodesk::Revit::DB::TemporaryGraphicsManager] to create and update an in-canvas control.

## Syntax (C#)
```csharp
public class InCanvasControlData : IDisposable
```

## Remarks
So far, only bitmap file is supported for ImagePath . The rendered image is the same size
 in pixel dimensions as the original one. To get a better result, the caller should prepare the image with proper size, for exmaple: 32x32 or 64x64 in pixels,
 before use. To achive a "transparent" backgound color effect over the provided bitmap, the bitmap should use color RGB(0, 128, 128) as its background and
 it will be cleared during rendering by Revit.

