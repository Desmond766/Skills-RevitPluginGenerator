---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.Get2DContextHandle
source: html/9e027616-9f33-ede2-d25f-1fe4e3b38445.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.Get2DContextHandle Method

Obtains the IfcRepresentationContext handle to be used for 2D entities (Annotations).

## Syntax (C#)
```csharp
public IFCAnyHandle Get2DContextHandle()
```

## Returns
The IfcRepresentationContext.

## Remarks
The context handle is automatically applied with a 1:100 scale.

