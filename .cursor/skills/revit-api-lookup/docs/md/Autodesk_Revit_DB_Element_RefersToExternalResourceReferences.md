---
kind: method
id: M:Autodesk.Revit.DB.Element.RefersToExternalResourceReferences
zh: 构件、图元、元素
source: html/387c00cd-3932-76e6-152b-bfe4efb8fbc1.htm
---
# Autodesk.Revit.DB.Element.RefersToExternalResourceReferences Method

**中文**: 构件、图元、元素

Determines whether this Element uses external resources.

## Syntax (C#)
```csharp
public bool RefersToExternalResourceReferences()
```

## Returns
True if this element uses external resources, false if it does not.

## Remarks
Some elements may contain references to data from external resources.
 These elements contain one or more ExternalResourceReferences.

