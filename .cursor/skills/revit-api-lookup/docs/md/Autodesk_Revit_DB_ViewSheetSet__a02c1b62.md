---
kind: type
id: T:Autodesk.Revit.DB.ViewSheetSet
source: html/5553be2c-8ce7-cbc1-b99e-85c74bcf28d3.htm
---
# Autodesk.Revit.DB.ViewSheetSet

Represents ViewSheetSets stored in a document.
ViewSheetSets can be stored so that the same printing task can be executed multiple times.

## Syntax (C#)
```csharp
public class ViewSheetSet : Element, 
	IViewSheetSet
```

## Remarks
For the in-session ViewSheetSet, see the class InSessionViewSheetSet .
Changes of ViewSheetSet would be effiective after [!:Autodesk::Revit::DB::ViewSheetSetting::Save]

