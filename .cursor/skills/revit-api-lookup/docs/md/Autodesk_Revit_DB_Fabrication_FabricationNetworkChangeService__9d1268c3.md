---
kind: type
id: T:Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService
source: html/ddd58cb0-54bc-a864-9688-b890a7140112.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService

This class represents the fabrication part change service and change size tools.

## Syntax (C#)
```csharp
public class FabricationNetworkChangeService : IDisposable
```

## Remarks
After a new instance of the class is created, call the ChangeService method to change the service of the
 fabrication parts or call the ChangeSize method to change the size of the fabrication parts. There is another
 workflow allowing for more control, call SetSelection to set the selection of fabrication parts to change. To change
 the service, call SetServiceId and SetPaletteId to set the service identifier and palette identifier. Changing
 the service there is an optional methods GetInLinePartTypes and SetMapOfSizesForStraights that can be called
 to replace in-line valves and dampers to the corresponding parts for the new service. The size can also be changed by calling
 GetMapOfAllSizesForStraights that will return a FabricationPartSizeMapSet containing a map of sizes for all straights
 found in the selection of fabrication parts. The FabricationPartSizeMapSet can then be modified to set the mapped values for
 the new size for the fabrication part straights and then call SetMapOfSizesForStraights set the new sizes that are to
 be applied. Finally call ApplyChange to apply the previously set parameters to the selection of fabrication parts.
 GetStraightsThatWereNotChanged () () () to get a set of fabrication part straight element identifiers that were not changed. GetElementsThatFailed () () () to get a set of fabrication part element identifiers that had failures.

