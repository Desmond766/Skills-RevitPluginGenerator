---
kind: method
id: M:Autodesk.Revit.DB.ComponentRepeaterSlot.IsTypeValidForSlot(Autodesk.Revit.DB.ElementId)
source: html/26db1b51-32b3-5535-7c3e-74bae8462fcb.htm
---
# Autodesk.Revit.DB.ComponentRepeaterSlot.IsTypeValidForSlot Method

Determines whether instance of given family type can be used in the component repeater slot.

## Syntax (C#)
```csharp
public bool IsTypeValidForSlot(
	ElementId typeId
)
```

## Parameters
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The element id of the type.

## Returns
True if the family type can be used in the component repeater slot.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

