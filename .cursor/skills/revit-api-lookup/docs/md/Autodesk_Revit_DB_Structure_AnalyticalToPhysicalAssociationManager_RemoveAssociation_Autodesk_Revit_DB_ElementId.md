---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.RemoveAssociation(Autodesk.Revit.DB.ElementId)
source: html/05d00613-cf7f-ea84-61a4-b6ce4805dafd.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.RemoveAssociation Method

This method will remove the association for the element with the given ElementId.

## Syntax (C#)
```csharp
public void RemoveAssociation(
	ElementId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - Id of the element for which we want to remove the association.

## Remarks
If the id does not have any association, an exception is thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This element doesn't have an association defined.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

