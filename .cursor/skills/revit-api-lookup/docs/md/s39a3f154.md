---
kind: method
id: M:Autodesk.Revit.DB.Element.GetExternalResourceReferencesExpanded
zh: 构件、图元、元素
source: html/954cb21e-5c4e-1e52-7e35-1eb0ed4b050b.htm
---
# Autodesk.Revit.DB.Element.GetExternalResourceReferencesExpanded Method

**中文**: 构件、图元、元素

Gets the expanded map of the external resource references referenced
 by the element.

## Syntax (C#)
```csharp
public IDictionary<ExternalResourceType, IList<ExternalResourceReference>> GetExternalResourceReferencesExpanded()
```

## Returns
The expanded map of the external resource references referenced by the element.

## Remarks
The value includes all external resource references under the type.
 Use this API for an element which has multiple external resource references
 under a specified type, e.g., AppearanceAssetElement.
 See also: [!:Autodesk::Revit::DB::Element::getExternalResourceReferences] .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Element does not use any external resource.

