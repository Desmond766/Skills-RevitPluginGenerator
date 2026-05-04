---
kind: method
id: M:Autodesk.Revit.DB.View3D.SaveOrientation
zh: 三维视图、3d视图
source: html/ce6a54f4-9a7f-1131-6a67-fc65286feea4.htm
---
# Autodesk.Revit.DB.View3D.SaveOrientation Method

**中文**: 三维视图、3d视图

Converts the temporary orientation of the View3D into its saved orientation.

## Syntax (C#)
```csharp
public void SaveOrientation()
```

## Remarks
The View3D will be oriented to its saved orientation on file open.
 To save the orientation of the default View3D, first rename the default View3D.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The orientation of the View3D cannot be saved.

