---
kind: method
id: M:Autodesk.Revit.DB.LinkLoadResult.GetParentModelName
source: html/e7006cf3-c4d1-a8c3-9bc2-4478a91b0188.htm
---
# Autodesk.Revit.DB.LinkLoadResult.GetParentModelName Method

Returns the name of the parent of the linked model, or an empty FilePath
 if the link is a top-level link.

## Syntax (C#)
```csharp
public ModelPath GetParentModelName()
```

## Remarks
This function is only relevant for LinkLoadResult object for RvtLinkSymbol.
 ie. when getIsRvtLink() is true.

