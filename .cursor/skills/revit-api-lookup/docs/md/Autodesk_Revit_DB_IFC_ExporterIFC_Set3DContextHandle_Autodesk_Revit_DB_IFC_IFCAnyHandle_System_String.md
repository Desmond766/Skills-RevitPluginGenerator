---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.Set3DContextHandle(Autodesk.Revit.DB.IFC.IFCAnyHandle,System.String)
source: html/94faf2de-158e-87bc-a9e0-ad0e6ff8eedc.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.Set3DContextHandle Method

Sets the IfcRepresentationContext or IfcRepresentationSubContext handle to be used for 3D entities (Model entities).

## Syntax (C#)
```csharp
public void Set3DContextHandle(
	IFCAnyHandle contextHandle,
	string subContextName
)
```

## Parameters
- **contextHandle** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The IfcRepresentationContext for 3D entities.
- **subContextName** (`System.String`) - The name of the IfcRepresentationSubContext, or the IfcRepresentationContext if the string is empty, for 3D entities.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

