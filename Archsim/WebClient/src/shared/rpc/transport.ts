import { createGrpcWebTransport } from '@connectrpc/connect-web'
import { config } from '../config/env'

export const rpcTransport = createGrpcWebTransport({
  baseUrl: config.serverUrl,
})
