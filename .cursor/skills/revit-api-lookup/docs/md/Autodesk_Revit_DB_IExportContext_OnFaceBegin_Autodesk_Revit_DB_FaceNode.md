---
kind: method
id: M:Autodesk.Revit.DB.IExportContext.OnFaceBegin(Autodesk.Revit.DB.FaceNode)
source: html/9a9f37ae-c8c2-7355-2c3b-f26762951f1d.htm
---
# Autodesk.Revit.DB.IExportContext.OnFaceBegin Method

This method marks the beginning of a Face to be exported.

## Syntax (C#)
```csharp
RenderNodeAction OnFaceBegin(
	FaceNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.FaceNode`) - An output node that represents a Face.

## Returns
Return RenderNodeAction. Proceed if you wish to receive geometry (polymesh)
 for this face, or return RenderNodeAction.Skip otherwise.

## Remarks
Note that this method (as well as OnFaceEnd) is invoked only if the custom
 exporter was set up to include geometric objects in the output stream.
 See IncludeGeometricObjects for mode details.

