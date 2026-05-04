---
kind: property
id: P:Autodesk.Revit.DB.Element.VersionGuid
zh: 构件、图元、元素
source: html/2a1eae53-2c5c-a7be-1ef2-0f48626c62f5.htm
---
# Autodesk.Revit.DB.Element.VersionGuid Property

**中文**: 构件、图元、元素

Get the element version Guid.

## Syntax (C#)
```csharp
public Guid VersionGuid { get; }
```

## Remarks
If element version Guid is the same for a certain element in two instances of the saved file
 then we guarantee that the two elements are identical. One element version covers a period of time
 that is larger than a single transaction: it is a period between two saves, synchronize to central and reload latest.
 Thus, in an opened document in-between saves or synchronize actions,
 this version cannot be used to determine if any particular element has changed. To watch for element changes happening in-session,
 use event [!:Autodesk::Revit::ApplicationServices::Application::DocumentChanged] .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When the Element is transient or when the Document has no version Guid for this Element.

