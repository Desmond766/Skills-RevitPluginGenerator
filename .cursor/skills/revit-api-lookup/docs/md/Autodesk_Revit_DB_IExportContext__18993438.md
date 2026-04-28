---
kind: type
id: T:Autodesk.Revit.DB.IExportContext
source: html/7d0dc6df-db0e-6a07-3b42-8dde1bedb3c1.htm
---
# Autodesk.Revit.DB.IExportContext

An interface that is used in custom export to process a Revit model.

## Syntax (C#)
```csharp
public interface IExportContext
```

## Remarks
An instance of a class that implements this interface is passed in as a
 parameter of the CustomExporter constructor.
 The methods of the context are then called at times of exporting entities of the model.
 This is a base class for two other interfaces derived from it:
 IPhotoRenderContext and
 IModelExportContext . This base class contains
 methods that are common
 to both the leaf interfaces. Although it is still possible to use classes
 deriving directly from this base interface (for backward compatibility),
 future applications should implement the new leaf interfaces only.

