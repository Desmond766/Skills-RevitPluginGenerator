---
kind: type
id: T:Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter
source: html/b2165e08-c8a4-5674-12ff-d359eba911d4.htm
---
# Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter

This class represents the MEP design to fabrication part convert tool.

## Syntax (C#)
```csharp
public class DesignToFabricationConverter : IDisposable
```

## Remarks
After a new instance of the class is created, call the Convert method to convert the MEP design elements into
 fabrication parts. Use the method SetMapForFamilySymbolToFabricationPartType to optionally convert family content
 to fabrication parts prior to calling Convert by providing a mapping of family symbols to fabrication parts types.
 If not set, then during conversion these families will remain and any connections to other converted elements will be
 maintained. After the convert method has been invoked, query the class to obtain more information about the conversion:
 GetConvertedFabricationParts () () () to get a set of element identifiers for the newly created fabrication parts. GetElementsWithOpenConnector () () () to get a set of fabrication part or MEP design element identifiers with open connectors, caused by fittings failing to convert.

