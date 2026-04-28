---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.IsSingleFabricSheetWithinHost(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Transform)
source: html/d0e85e9c-31f1-6ee4-c98b-8c124cc33d9c.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.IsSingleFabricSheetWithinHost Method

Identifies if the specified single Fabric Sheet position is within the host.

## Syntax (C#)
```csharp
public bool IsSingleFabricSheetWithinHost(
	Element hostElement,
	Transform transform
)
```

## Parameters
- **hostElement** (`Autodesk.Revit.DB.Element`) - A structural element that will host the Fabric Sheet.
- **transform** (`Autodesk.Revit.DB.Transform`) - The transform that defines the placement of the instance single Fabric Sheet.

## Returns
True if the single Fabric Sheet instance is within the host, false if the single Fabric Sheet instance is out of host.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

