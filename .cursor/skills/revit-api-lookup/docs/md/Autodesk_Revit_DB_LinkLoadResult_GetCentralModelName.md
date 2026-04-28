---
kind: method
id: M:Autodesk.Revit.DB.LinkLoadResult.GetCentralModelName
source: html/0c134190-7821-0528-b69c-0253eb0af981.htm
---
# Autodesk.Revit.DB.LinkLoadResult.GetCentralModelName Method

Gets the central model's name.
 If the link is not workshared, this returns an empty FilePath.
 If the link is itself a central model, this returns the link's name.

## Syntax (C#)
```csharp
public ModelPath GetCentralModelName()
```

## Remarks
If the link could not be found or loaded, this name may be blank.
This function is only relevant for LinkLoadResult object for RvtLinkSymbol.
 ie. when getIsRvtLink() is true.

