---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.Get3DContextHandle(System.String)
source: html/e1ea52a9-9e2c-9704-cfab-d43fe87fd53b.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.Get3DContextHandle Method

Obtains the IfcRepresentationContext or IfcRepresentationSubContext handle to be used for 3D entities (Model entities).

## Syntax (C#)
```csharp
public IFCAnyHandle Get3DContextHandle(
	string subContextName
)
```

## Parameters
- **subContextName** (`System.String`) - The name of the IfcRepresentationSubContext, or the IfcRepresentationContext if the string is empty, for 3D entities.

## Returns
The IfcRepresentationContext for 3D entities.

## Remarks
The context handle automatically incorporates the angle to true north for the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

