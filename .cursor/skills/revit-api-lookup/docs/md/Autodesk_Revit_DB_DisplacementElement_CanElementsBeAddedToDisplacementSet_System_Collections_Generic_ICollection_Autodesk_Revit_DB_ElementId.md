---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.CanElementsBeAddedToDisplacementSet(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/45d2fc58-535b-2b9b-2bf5-ccefd5f93123.htm
---
# Autodesk.Revit.DB.DisplacementElement.CanElementsBeAddedToDisplacementSet Method

Indicates if these elements can be displaced by this DisplacementElement.

## Syntax (C#)
```csharp
public bool CanElementsBeAddedToDisplacementSet(
	ICollection<ElementId> toDisplace
)
```

## Parameters
- **toDisplace** (`System.Collections.Generic.ICollection < ElementId >`) - The elements to displace.

## Returns
True if the elements can be displaced by this DisplacementElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

