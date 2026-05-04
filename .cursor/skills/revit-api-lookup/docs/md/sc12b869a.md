---
kind: type
id: T:Autodesk.Revit.DB.IndependentTag
zh: 标记、打标、标签
source: html/e52073e2-9d98-6fb5-eb43-288cf9ed2e28.htm
---
# Autodesk.Revit.DB.IndependentTag

**中文**: 标记、打标、标签

Represents tag annotations in Revit.

## Syntax (C#)
```csharp
public class IndependentTag : Element
```

## Remarks
IndependentTag represents single-category tags, multi-category tags, material tags, and zone tags.
 IndependentTag is also the base class for other annotations like keynote tags and span symbols.
 Room, area and space tags are not derived from IndependentTag. [!:Autodesk::Revit::DB::SpatialElementTag] for more information.

