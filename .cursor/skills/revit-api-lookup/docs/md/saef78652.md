---
kind: method
id: M:Autodesk.Revit.DB.CustomExporter.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.IExportContext)
source: html/98f23174-e29e-36a5-e3a4-c72144708553.htm
---
# Autodesk.Revit.DB.CustomExporter.#ctor Method

Constructs a new instance of a CustomExporter for a given document
 using the input instance of IExportContext as the output device.

## Syntax (C#)
```csharp
public CustomExporter(
	Document document,
	IExportContext context
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the model to be exported
- **context** (`Autodesk.Revit.DB.IExportContext`) - An instance of a context class that will be consuming the output

## Remarks
The input context should be an instance of a class that implements
 either IModelExportContext 
 or IPhotoRenderContext interfaces.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

