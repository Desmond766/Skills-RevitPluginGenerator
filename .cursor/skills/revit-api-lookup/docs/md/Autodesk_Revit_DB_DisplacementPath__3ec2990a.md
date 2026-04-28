---
kind: type
id: T:Autodesk.Revit.DB.DisplacementPath
source: html/90ac4bbb-7f65-763a-bf5e-a76b2a167294.htm
---
# Autodesk.Revit.DB.DisplacementPath

A view-specific annotation related to a DisplacementElement.

## Syntax (C#)
```csharp
public class DisplacementPath : Element
```

## Remarks
The DisplacementPath is anchored to the DisplacementElement by a reference to a point
 on an edge of a source element of the DisplacementElement. It is
 represented by a single line, or a series of jogged lines, originating at the specified point
 on the displaced element.
 The associated DisplacementElement may have a parent DisplacementElement and this parent may have its own parent DisplacementElement,
 producing a series of ancestors. The terminal point may be the point's original (un-displaced)
 location, or the corresponding point on any of the intermediate displaced locations corresponding
 to these ancestor DisplacementElements.

