---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHostData.GetCommonCoverType
source: html/eb1839ca-5de6-b651-6009-db078cb8fd91.htm
---
# Autodesk.Revit.DB.Structure.RebarHostData.GetCommonCoverType Method

If all exposed faces of the host have the same associated CoverType,
 return that CoverType; otherwise, return Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Syntax (C#)
```csharp
public RebarCoverType GetCommonCoverType()
```

## Returns
The common CoverType for all exposed faces, or Nothing nullptr a null reference ( Nothing in Visual Basic) 
 if there are multiple CoverTypes.

