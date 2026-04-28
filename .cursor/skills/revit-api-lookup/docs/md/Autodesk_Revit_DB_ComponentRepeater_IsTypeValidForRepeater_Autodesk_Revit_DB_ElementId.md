---
kind: method
id: M:Autodesk.Revit.DB.ComponentRepeater.IsTypeValidForRepeater(Autodesk.Revit.DB.ElementId)
source: html/64b2d4bf-7c8f-e641-5d78-e95565bc5c77.htm
---
# Autodesk.Revit.DB.ComponentRepeater.IsTypeValidForRepeater Method

Determines whether given family type can be used as the default type for the repeater.

## Syntax (C#)
```csharp
public bool IsTypeValidForRepeater(
	ElementId typeId
)
```

## Parameters
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The element id of the type.

## Returns
True if the family type can be used as the default type for the repeater.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

