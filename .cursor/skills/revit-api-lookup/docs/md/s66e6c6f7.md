---
kind: type
id: T:Autodesk.Revit.DB.NumberingSchemaType
source: html/da916345-8494-ff19-96d0-1a2d0377a02e.htm
---
# Autodesk.Revit.DB.NumberingSchemaType

A type for identifying a NumberingSchema of a particular kind.

## Syntax (C#)
```csharp
public class NumberingSchemaType : GuidEnum
```

## Remarks
Each numbering schema is applicable to a certain category of Revit elements. For example, the Rebar
 numbering schema (built-in) is used and only applicable to Rebar elements. With that schema present,
 all Rebar elements automatically will get their respective numbers and those numbers would not correspond
 in any way to numbers of other enumerable elements that belong to different numbering schemas. There are only built-in schemas available currently.

