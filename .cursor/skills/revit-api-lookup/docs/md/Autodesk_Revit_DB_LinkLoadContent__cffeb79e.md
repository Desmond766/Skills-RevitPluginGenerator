---
kind: type
id: T:Autodesk.Revit.DB.LinkLoadContent
source: html/72ac893d-d76a-2606-6bab-3d180b552610.htm
---
# Autodesk.Revit.DB.LinkLoadContent

This class is used by IExternalResourceServers to return Link data to Revit when their
 LoadResource method is invoked. It also contains additional information used by
 IExternalResourceUIServers to display link load status results to the user.

## Syntax (C#)
```csharp
public class LinkLoadContent : ExternalResourceLoadContent
```

## Remarks
This class handles Revit links. Revit links must be loaded from a path accessible to Revit.
 Server implementors should provide Revit with a ModelPath representing
 a location from which to load the link. Revit will handle the actual
 file loading. Servers which represent non-local file locations will need to
 create their own implementation for copying
 or moving files to a Revit-accessible location. The link data path used for link loading may be different from
 the path displayed to the
 user. The link data path represents the literal location of the
 file, whereas the link's display path represents what the user sees
 as the name of the link. See [!:Autodesk::Revit::DB::ExternalResourceReference::InSessionPath] 
 for more details on display paths.

