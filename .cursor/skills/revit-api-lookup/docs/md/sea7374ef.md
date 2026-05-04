---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.GetPhaseMap
source: html/4d322c11-c2b3-a096-4f10-3b23c9112308.htm
---
# Autodesk.Revit.DB.RevitLinkType.GetPhaseMap Method

Returns a mapping between phases in the host document and phases in the linked document.

## Syntax (C#)
```csharp
public IDictionary<ElementId, ElementId> GetPhaseMap()
```

## Returns
A map from phases in the host document to phases in the linked document.
 The first value in each pair is the ElementId of a phase in the host document.
 The second value is the ElementId of the matching phase in the linked document.

## Remarks
This map is used to determine which phase in the linked document corresponds to each phase in the host document.
 This map is used to correctly calculate room geometry for room-bounding links.
 Multiple phases in the host document can correspond to the same phase in the linked document.
 Time order must be respected - if the host document has phases 1 and 2, and the linked document
 has phases A and B, it would not be proper to map 1 to B and 2 to A.
 If the user has not explicitly set the map values in the UI, the map will be as follows: Revit attempts to find
 a match for each host phase, moving in order from earliest to latest phase.
 First Revit will look for a phase in the linked document with the same name as the host phase.
 If there is no name match, the last phase in the link will be chosen as the match.
 Once Revit has matched a host phase to the last link phase, all other host phases will be matched to the last link phase,
 even if later host phases might have a name match.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RvtLinkSymbol is not loaded.
 -or-
 This Revit link doesn't have a valid phase map.

