---
kind: property
id: P:Autodesk.Revit.DB.Element.Parameters
zh: 构件、图元、元素
source: html/7af5d66f-4533-33d2-dd82-d9573eaabf15.htm
---
# Autodesk.Revit.DB.Element.Parameters Property

**中文**: 构件、图元、元素

Retrieves a set containing all of the parameters that are contained within the element.

## Syntax (C#)
```csharp
public ParameterSet Parameters { get; }
```

## Remarks
The Parameters property contains a set of all the parameters that the element supports.
These parameters are displayed in the Element properties dialog in the Autodesk Revit interface.
These parameters can be retrieved and set via the parameter objects stored in this set.

