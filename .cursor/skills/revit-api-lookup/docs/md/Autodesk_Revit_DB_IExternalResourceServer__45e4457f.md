---
kind: type
id: T:Autodesk.Revit.DB.IExternalResourceServer
source: html/c2ad8eee-b358-012b-a09b-8fbc3229652d.htm
---
# Autodesk.Revit.DB.IExternalResourceServer

The interface used to provide custom implementation to provide access to external resources (such as linked files) from arbitrary locations.

## Syntax (C#)
```csharp
public interface IExternalResourceServer : IExternalServer
```

## Remarks
Certain resources used in a Revit model are stored outside of the .rvt file. For example, the data used
 for keynotes, images used as decals during rendering, CAD links, and Revit links are all stored outside
 the model. Creating a new implementation of this server allows the server to supply one or more types of such resources from
 an arbitrary source. For example, a server could provide the keynote data from a database or from
 a file format that Revit does not support. If a model references resources supplied by this server, Revit will request the resource from the server
 when it is required. Most external resources are loaded into memory at the time the model is loaded. The
 server will also be invoked if the resource is explicitly reloaded. IExternalResourceServer can declare that a resource is already up-to-date via
 GetResourceVersionStatus(ExternalResourceReference) If the resource is
 up-to-date, Revit will skip loading to improve performance. Each resource load request will be associated with a GUID, so that server implementers can uniquely identify
 a given load request. This may be useful to, for example, store server-side errors associated with an
 attempt to load a particular resource. If your server handles Revit or CAD links, you must take special care with link paths. When one of these
 file types is uploaded to your server, any nested references should be brought to the server along with the
 main link. Your server will need to repath any nested reference itself; Revit will not handle this automatically. In the case of DWG links, your server will also need to download and possibly repath any xrefs when
 LoadResource is called for the top-level link. Revit will only request the top-level link directly. In the case of Revit links, the ExternalResourceReferences for any nested links will also
 need to be modified in the host document. The host document should reference the Revit links at their
 server locations, not their local file locations. Revit may not be able to find links if the
 paths are not set up correctly. See [!:Autodesk::Revit::DB::TransmissionData::ReadTransmissionData] 
 to inspect the set of links contained within a Revit model. See
 [!:Autodesk::Revit::DB::RevitLinkType::LoadFrom] to reload a Revit link from a server version. Here is an example which uses nested Revit links: A user has a Revit model containing one link, Link.rvt, which
 contains one nested link, Nest.rvt. The user uploads Link.rvt to a server, using an add-in provided by that
 server. The server provider must also take Nest.rvt. Further, the server provider must open Link.rvt and modify
 the reference to Nest.rvt so that it references the version on the server. Otherwise, Revit will not be able to
 find Nest.rvt when another user tries to load Link.rvt from the server. The external resource framework has been designed to allow server authors to display UI related to the resource
 load operation and UI browse operation. No UI should be displayed directly from an IExternalResourceServer. 
 Instead, developers should create an IExternalResourceUIServer which will handle UI tasks on behalf of the IExternalResourceServer.
 For more information, see the documentation for the LoadResource(Guid, ExternalResourceType, ExternalResourceReference, ExternalResourceLoadContext, ExternalResourceLoadContent) and SetupBrowserData(ExternalResourceBrowserData) methods.

