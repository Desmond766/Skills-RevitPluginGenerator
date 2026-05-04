---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.HasAssociation(Autodesk.Revit.DB.ElementId)
source: html/2534dbba-e2c6-e85d-5b96-c7b610993b15.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.HasAssociation Method

Verifies if the element has already defined an association.

## Syntax (C#)
```csharp
public bool HasAssociation(
	ElementId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - Id of the element to check.

## Returns
Returns true if an association has been found, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

