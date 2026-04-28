---
kind: property
id: P:Autodesk.Revit.DB.ReferenceIntersector.FindReferencesInRevitLinks
zh: 射线、射线相交
source: html/027d8736-697e-ebe8-37d9-901f96713540.htm
---
# Autodesk.Revit.DB.ReferenceIntersector.FindReferencesInRevitLinks Property

**中文**: 射线、射线相交

Determines if references inside Revit Links should be found.

## Syntax (C#)
```csharp
public bool FindReferencesInRevitLinks { get; set; }
```

## Remarks
If set to false, no Reference to any Element from a Revit Link will be found by the ReferenceIntersector,
 and you can be certain that any Reference returned will be to a host document Element only. If set to true,
 the results may include both References to Elements in hosts and References to Elements from a link
 instance. Setting this value to true may interact with some other settings on the ReferenceIntersector. If a list of target ElementIds is set,
 references will be returned only if the ElementId matches the id of the intersected RevitLinkInstance. If there is a match, any intersecting
 elements in the link will be returned (their ids will not be compared with the target ids list). If there is an ElementFilter
 applied, the elements in the link will be evaluated against the stored ElementFilter. Note that results may not be as expected if the filter applied is geometric (such as a BoundingBox filter or ElementIntersects filter).
 This is because the filter will be evaluated for linked elements in the coordinates of the linked model, which may not match the coordinates
 of the elements as they appear in the host model. Also, ElementFilters that accept a Document and/or ElementId as input during
 their instantiation will not correctly pass elements that appear in the link, because the filter will not be able to match link elements to
 the filter's criteria.

