---
kind: type
id: T:Autodesk.Revit.DB.ColorFillScheme
source: html/c405eb5b-14fa-0fea-a750-dcd9925a90b0.htm
---
# Autodesk.Revit.DB.ColorFillScheme

Represents a color scheme could be used to colorfy elements in floor plan views and section views.

## Syntax (C#)
```csharp
public class ColorFillScheme : Element
```

## Remarks
A color scheme is based on element category and one of the category parameter, it contains a
 set of ColorFillSchemeEntry which stores parameter value,
 color, fill pattern and other entry data. The entry paramater values may be a range or a single value,
 based on the IsByRange property. Then elements with the specified category
 could be colored with the color and fill pattern of matching entry whose parameter value or value range
 matches the element parameter value. You can retrieve the entries with GetEntries () () () , or modify entries with
 AddEntry(ColorFillSchemeEntry) , RemoveEntry(ColorFillSchemeEntry) , UpdateEntry(ColorFillSchemeEntry) and [M:Autodesk.Revit.DB.ColorFillScheme.SetEntries(System.Collections.Generic.IList`1{Autodesk.Revit.DB.ColorFillSchemeEntry})] . Unlike most of the other elements, the color scheme works in an "asynchronous" way in UI: If document elements change, the color scheme will not be updated immediately. If color schemes changes, the document elements will not be updated immediately too. API works slightly different with UI: GetEntries () () () will return the entries corresponding to the latest document elements status immediately. The entries modification operation will retrieve the latest entries with GetEntries () () () at first, and then modify
 those entries by request, but document elements will still not be updated immediately. To modify multiple entries, it's better to use [M:Autodesk.Revit.DB.ColorFillScheme.SetEntries(System.Collections.Generic.IList`1{Autodesk.Revit.DB.ColorFillSchemeEntry})] but not modify them one by one with other methods
 for better performance. Notes: To apply a color scheme whose CategoryId property is OST_Areas to an area plan view,
 the AreaSchemeId property must be the same as the view if it is not used as a template. To generate a new color scheme, you have to use Duplicate(String) method to duplicate form an existing one. There should not exist two entries values that are the same in a color scheme. if the StorageType property is Double,
 then the value accuracy should be based on FormatOptions property.

