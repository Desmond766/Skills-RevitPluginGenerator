---
kind: method
id: M:Autodesk.Revit.DB.Element.GetExternalResourceReferences
zh: 构件、图元、元素
source: html/7df4341b-5102-8016-d6fa-45bc27e8c3af.htm
---
# Autodesk.Revit.DB.Element.GetExternalResourceReferences Method

**中文**: 构件、图元、元素

Gets the map of the external resource references referenced
 by the element.

## Syntax (C#)
```csharp
public IDictionary<ExternalResourceType, ExternalResourceReference> GetExternalResourceReferences()
```

## Returns
The map of the external resource references referenced by the element.

## Remarks
For an element which has multiple external resource references
 under a specified type like AppearanceAssetElement, the first one will be the value in the map.
 See also: [!:Autodesk::Revit::DB::Element::getExternalResourceReferencesExpanded] .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Element does not use any external resource.

