---
kind: method
id: M:Autodesk.Revit.DB.LinkLoadResult.GetNestedLinkLoadResults
source: html/098e7995-b0bd-7197-0336-4a597f53eb9d.htm
---
# Autodesk.Revit.DB.LinkLoadResult.GetNestedLinkLoadResults Method

Gets the results for this link's nested links.

## Syntax (C#)
```csharp
public IDictionary<string, LinkLoadResult> GetNestedLinkLoadResults()
```

## Returns
A map from nested link paths to the load results for
 that nested link. For links from external servers, the "path" will be
 the display name of the link.

## Remarks
This function is only relevant for LinkLoadResult object for RvtLinkSymbol.
 ie. when getIsRvtLink() is true.

