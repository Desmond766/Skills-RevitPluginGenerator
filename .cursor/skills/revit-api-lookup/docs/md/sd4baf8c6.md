---
kind: type
id: T:Autodesk.Revit.DB.IModelExportContext
source: html/4309af43-f04e-4e42-2539-3fd1d64cdc6d.htm
---
# Autodesk.Revit.DB.IModelExportContext

An interface that is used in custom export to export 3D views of a Revit model.

## Syntax (C#)
```csharp
public interface IModelExportContext : IExportContextBase
```

## Remarks
An instance of a class that implements this interface is passed in as a
 parameter of the CustomExporter constructor.
 The interface methods are then called at times of drawing entities that are
 currently visible in the view being exported. 
 With this type of export context used to perform a custom export,
 Revit will traverse the model and output the model's geometry
 as if in the process of regular displaying or exporting a 3D View.
 It means that any geometry which is visible in an open view
 (taking any current visibility setting applicable to the view)
 will be processed and output.

