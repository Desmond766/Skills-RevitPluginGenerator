---
kind: property
id: P:Autodesk.Revit.DB.Element.ParametersMap
zh: 构件、图元、元素
source: html/82c45482-a018-32e4-d8e5-9751e10ffeb9.htm
---
# Autodesk.Revit.DB.Element.ParametersMap Property

**中文**: 构件、图元、元素

Retrieves a map containing all of the parameters that are contained within the element.

## Syntax (C#)
```csharp
public ParameterMap ParametersMap { get; }
```

## Remarks
The Parameters can be rapidly accessed by parameter name as a key.
These parameters are displayed in the Element properties dialog in the Autodesk Revit interface.
These parameters can be retrieved and set via the parameter objects stored in this map.

