---
kind: type
id: T:Autodesk.Revit.DB.ComponentRepeaterSlot
source: html/395d3527-1315-038e-8a47-80920f063cc6.htm
---
# Autodesk.Revit.DB.ComponentRepeaterSlot

Represents a slot that holds one repeated component in a component repeater.

## Syntax (C#)
```csharp
public class ComponentRepeaterSlot : Element
```

## Remarks
Each slot can be in one of the following states:
 Empty. Occupied by an instance of the default family of the repeater that contains the slot. Occupied by an instance of another family. 
 Initially, every occupied slot holds an instance of the default family of the repeater, based on the original
 element that was repeated.

