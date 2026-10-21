import { createClient } from '@connectrpc/connect'
import { Nodes } from '../../contracts/rpc/Nodes/NodesService_pb'
import { rpcTransport } from './transport'

export const nodesClient = createClient(Nodes, rpcTransport)
