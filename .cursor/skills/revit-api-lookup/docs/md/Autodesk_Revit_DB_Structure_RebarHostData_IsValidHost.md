---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHostData.IsValidHost
source: html/c1c4d8ff-4636-67b6-75d2-7c37a17a7276.htm
---
# Autodesk.Revit.DB.Structure.RebarHostData.IsValidHost Method

Reports whether the element is a valid rebar host.

## Syntax (C#)
```csharp
public bool IsValidHost()
```

## Returns
True if the referenced Element can currently host Rebar elements,
 false otherwise.

## Remarks
If GetRebarHostData() returns a RebarHostData object,
 but RebarHostData.IsValidHost() returns false, this means
 that the element can be made
 a valid rebar host, generally by setting a property
 like FLOOR_PARAM_IS_STRUCTURAL or by changing the
 element's physical material to concrete. On the other
 hand, if GetRebarHostData() returns Nothing nullptr a null reference ( Nothing in Visual Basic) , the element
 cannot be made into a rebar host.

