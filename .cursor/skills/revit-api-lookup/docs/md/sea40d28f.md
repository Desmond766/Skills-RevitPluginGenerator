---
kind: type
id: T:Autodesk.Revit.DB.Steel.SteelElementProperties
source: html/911b649a-d108-14a2-dc09-8e97d489c17d.htm
---
# Autodesk.Revit.DB.Steel.SteelElementProperties

This class is used to attach steel fabrication information to various Revit elements.

## Syntax (C#)
```csharp
public class SteelElementProperties : APIObject
```

## Remarks
Revit elements which can have fabrication information are:
 FamilyInstance (structural beams and columns). StructuralConnectionHandler elements associated to the connection. Specific steel connection elements (bolts, anchors, plates, etc). These connection elements will be of type element but with categories related to structural connections, for example:
 OST_StructConnectionWelds OST_StructConnectionHoles OST_StructConnectionModifiers OST_StructConnectionShearStuds OST_StructConnectionBolts OST_StructConnectionAnchors OST_StructConnectionPlates Some concrete elements (walls, floors, concrete beams, ...) when they are input elements to detailed steel connections. 
 The class also holds the link to the Steel Core elements.

