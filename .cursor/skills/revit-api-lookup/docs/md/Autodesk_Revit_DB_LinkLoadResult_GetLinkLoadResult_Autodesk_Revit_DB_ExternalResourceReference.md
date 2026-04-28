---
kind: method
id: M:Autodesk.Revit.DB.LinkLoadResult.GetLinkLoadResult(Autodesk.Revit.DB.ExternalResourceReference)
source: html/4a95fab0-b61f-10d5-045b-539eee095135.htm
---
# Autodesk.Revit.DB.LinkLoadResult.GetLinkLoadResult Method

Searches this LinkLoadResult and all nested LinkLoadResults for the
 load operation results of a specified ExternalResourceReference.

## Syntax (C#)
```csharp
public LinkLoadResult GetLinkLoadResult(
	ExternalResourceReference matchExtResRef
)
```

## Parameters
- **matchExtResRef** (`Autodesk.Revit.DB.ExternalResourceReference`) - An ExternalResourceReference whose LinkLoadResults are contained in this object.

## Returns
A LinkLoadResult object with the load results for the specified ExternalResourceReference.

## Remarks
In the case where there are multiple matches, then the LinkLoadResult closest
 to the top-level link will be returned. For example, if you are searching for C,
 starting with a top-level link, A, which links B and C, while B also links C directly,
 then the load results for C as a direct sub-link of A will be returned. It is expected
 that the LinkLoadResults for all instances of C in the nested load result tree will be
 the same. However, if you need to inspect each individual result, the LinkLoadResult
 class does provide methods to navigate the tree. NULL is returned if a match for the ExternalResourceReference cannot be found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

