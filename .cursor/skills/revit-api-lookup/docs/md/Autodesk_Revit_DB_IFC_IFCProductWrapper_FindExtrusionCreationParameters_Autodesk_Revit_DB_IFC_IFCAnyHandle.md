---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCProductWrapper.FindExtrusionCreationParameters(Autodesk.Revit.DB.IFC.IFCAnyHandle)
source: html/dab9ac70-4f27-9013-d067-8e21acbfccdb.htm
---
# Autodesk.Revit.DB.IFC.IFCProductWrapper.FindExtrusionCreationParameters Method

Obtains the extrusion creation data associated with the given element.

## Syntax (C#)
```csharp
public IFCExtrusionCreationData FindExtrusionCreationParameters(
	IFCAnyHandle elementHandle
)
```

## Parameters
- **elementHandle** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The handle.

## Returns
The parameters. Nothing nullptr a null reference ( Nothing in Visual Basic) if no parameters are associated with the element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

