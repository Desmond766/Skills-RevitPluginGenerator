---
kind: property
id: P:Autodesk.Revit.DB.BindingMap.Item(Autodesk.Revit.DB.Definition)
source: html/a8dc01fc-7c56-2fd8-8340-a7fbf7bcc7b4.htm
---
# Autodesk.Revit.DB.BindingMap.Item Property

The get_Item method will get the binding item related to the input key.

## Syntax (C#)
```csharp
public override Binding this[
	Definition key
] { get; set; }
```

## Parameters
- **key** (`Autodesk.Revit.DB.Definition`) - A parameter definition which can be an existing definition or one from a shared parameters file.

## Remarks
set_Item is not permitted for this class. A Autodesk::Revit::Exceptions::InvalidOperationException will be thrown. 
Instead use Insert, Remove and ReInsert to modify the bindings in the document.

