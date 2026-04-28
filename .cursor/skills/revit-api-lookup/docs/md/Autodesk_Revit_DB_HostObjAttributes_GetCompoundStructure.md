---
kind: method
id: M:Autodesk.Revit.DB.HostObjAttributes.GetCompoundStructure
source: html/a1ec47e5-c552-944d-2152-74d7bd3f2a31.htm
---
# Autodesk.Revit.DB.HostObjAttributes.GetCompoundStructure Method

Returns an object that represents the compound structure of the element.

## Syntax (C#)
```csharp
public CompoundStructure GetCompoundStructure()
```

## Remarks
A copy of the compound structure is returned and changes made to it will not apply to the type until SetCompoundStructure is called.
From this object the layers of a compound structure can be accessed. If the element does
not have a compound structure then this method will return Nothing nullptr a null reference ( Nothing in Visual Basic) .

