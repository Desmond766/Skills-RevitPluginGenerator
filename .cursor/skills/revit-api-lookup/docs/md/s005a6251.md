---
kind: type
id: T:Autodesk.Revit.DB.IPhotoRenderContext
source: html/d09d4ea2-1090-f2b9-8073-5fb8a796babf.htm
---
# Autodesk.Revit.DB.IPhotoRenderContext

An interface that is used in custom export to render 3D views of a Revit model.

## Syntax (C#)
```csharp
public interface IPhotoRenderContext : IExportContext
```

## Remarks
An instance of a class that implements this interface is passed in as a
 parameter of the CustomExporter constructor.
 The interface methods are then called at times of rendering entities that are
 currently visible in the view being rendered. With this type of export context used to perform a custom export,
 Revit will traverse the model and output the model's geometry
 as if processing the Render command invoked via the UI. It means
 that only such elements that have actual geometry and are suitable
 to appear in a rendered view will be processed and output.

